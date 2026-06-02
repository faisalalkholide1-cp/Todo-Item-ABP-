import { Component, inject, OnInit } from '@angular/core';
import { FormsModule } from "@angular/forms";
import { ToasterService } from "@abp/ng.theme.shared";
import { TodoItemDto, CreateTodoDto } from '../proxy/todo-items/models';
import { TodoService } from '../proxy/todo-items/todo.service';
import { NgFor, NgIf } from '@angular/common';
import { ConfigStateService } from '@abp/ng.core';

@Component({
  selector: 'app-todo-item',
  imports: [FormsModule, NgIf, NgFor],
  templateUrl: './todo-item.html',
  styleUrl: './todo-item.scss',
})
export class TodoItem implements OnInit {
  todoItems: TodoItemDto[] = [];
  newTodoText = '';
  editingId: string | null = null;
  editingText = '';
  canCreate = true;
  canEdit   = true;
  canDelete = true;

  readonly todoService = inject(TodoService);
  readonly toasterService = inject(ToasterService);
  readonly configState = inject(ConfigStateService);

  ngOnInit(): void {
     this.canCreate = this.configState
      .getDeep('auth.grantedPolicies.TodoApp.TodoItems.Create');
    this.canEdit   = this.configState
      .getDeep('auth.grantedPolicies.TodoApp.TodoItems.Edit');
    this.canDelete = this.configState
      .getDeep('auth.grantedPolicies.TodoApp.TodoItems.Delete');
      
    this.loadList();
  }

  loadList(): void {
    this.todoService.getList().subscribe(response => {
      this.todoItems = response;
    });
  }

  create(): void {
    if (!this.newTodoText.trim()) return;

    const input: CreateTodoDto = { text: this.newTodoText };

    this.todoService.create(input).subscribe({
      next: (result) => {
        this.todoItems = this.todoItems.concat(result);
        this.newTodoText = '';
        this.toasterService.success('تمت إضافة المهمة بنجاح');
      },
      error: () => {
        this.toasterService.error('هذه المهمة موجودة مسبقاً');
      }
    });
  }

  startEdit(item: TodoItemDto): void {
    this.editingId = item.id!;
    this.editingText = item.text!;
  }

  confirmEdit(id: string): void {
    if (!this.editingText.trim()) return;

    const input: CreateTodoDto = { text: this.editingText };

    this.todoService.update(id, input).subscribe({
      next: () => {
        this.todoItems = this.todoItems.map(item =>
          item.id === id ? { ...item, text: this.editingText } : item
        );
        this.editingId = null;
        this.toasterService.success('تم تعديل المهمة بنجاح');
      },
      error: () => {
        this.toasterService.error('حدث خطأ أثناء التعديل');
      }
    });
  }

  cancelEdit(): void {
    this.editingId = null;
    this.editingText = '';
  }

  delete(id: string): void {
    this.todoService.delete(id).subscribe({
      next: () => {
        this.todoItems = this.todoItems.filter(item => item.id !== id);
        this.toasterService.success('تم حذف المهمة بنجاح');
      },
      error: () => {
        this.toasterService.error('حدث خطأ أثناء الحذف');
      }
    });
  }
}