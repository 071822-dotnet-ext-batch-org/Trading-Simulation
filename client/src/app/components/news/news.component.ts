
import { Component, OnInit } from '@angular/core';
import { NewsService } from 'src/app/service/news.service';
import { News } from 'src/Models/News';

@Component({
  selector: 'app-news',
  templateUrl: './news.component.html',
  styleUrls: ['./news.component.css']
})
export class NewsComponent implements OnInit {
  title = 'Stock News';
  newsData: any;

  constructor(private nservice: NewsService) { }

   
    ngOnInit(): void {
      this.getNewsData()
    }
    
    getNewsData(): void{
      this.nservice.getNewsData()
      .subscribe(newsData => this.newsData = (newsData.data))
    }
  }
    