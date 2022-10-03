import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { IPost } from '../interfaces';

const apiUrl = environment.apiUrl;

@Injectable()
export class PostService {

  constructor(private httpClient: HttpClient) { }

  loadPostList(limit?: number): Observable<IPost[]> {
    return this.httpClient.get<IPost[]>(`${apiUrl}/posts${limit ? `?limit=${limit}` : ''}`)
  }
}
