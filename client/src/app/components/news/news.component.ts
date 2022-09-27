
import { Component, OnInit } from '@angular/core';
import { NewsService } from 'src/app/Services/news/news.service';
import { News } from 'src/app/Models/News';

@Component({
  selector: 'app-news',
  templateUrl: './news.component.html',
  styleUrls: ['./news.component.css']
})
export class NewsComponent implements OnInit {
  title = 'Stock News';
  newsData: any;


  constructor(private GetNewsService: NewsService) { }

   
    ngOnInit(): void {
        const news = localStorage.getItem('newsData')
      if (!news) {
        this.GetNewsService.getNews().subscribe(nd => 
          {
            this.newsData = nd.results
            localStorage.setItem('newsData', JSON.stringify(nd))
          })
        }
      else {
        const parseNews = JSON.parse(news || "")
        this.newsData = parseNews.results
      }
      
    }}