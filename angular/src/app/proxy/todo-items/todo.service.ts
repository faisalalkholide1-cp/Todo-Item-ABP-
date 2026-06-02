import type { CreateTodoDto, TodoItemDto } from './models';
import { RestService, Rest } from '@abp/ng.core';
import { Injectable, inject } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class TodoService {
  private restService = inject(RestService);
  apiName = 'Default';
  

  create = (input: CreateTodoDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, TodoItemDto>({
      method: 'POST',
      url: '/api/app/todo',
      body: input,
    },
    { apiName: this.apiName,...config });
  

  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/todo/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getList = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, TodoItemDto[]>({
      method: 'GET',
      url: '/api/app/todo',
    },
    { apiName: this.apiName,...config });
  

  update = (id: string, input: CreateTodoDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'PUT',
      url: `/api/app/todo/${id}`,
      body: input,
    },
    { apiName: this.apiName,...config });
}