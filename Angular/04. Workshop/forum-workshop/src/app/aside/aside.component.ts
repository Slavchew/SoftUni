import { Component, OnInit } from '@angular/core';
import { IPost } from '../interfaces';
import { PostService } from '../services/post.service';

@Component({
  selector: 'app-aside',
  templateUrl: './aside.component.html',
  styleUrls: ['./aside.component.css']
})
export class AsideComponent implements OnInit {

  postList: IPost[] = [];

  constructor(private postService: PostService) { }

  ngOnInit(): void {
    this.postService.loadPostList(5).subscribe(postList => {
      this.postList = postList;
    })
  }

}
