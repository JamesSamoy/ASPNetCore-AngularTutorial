import { Component, OnInit } from '@angular/core';
import {TopicDataService} from '../../services/topic-data.service';

@Component({
  selector: 'app-topics',
  templateUrl: './topics.component.html',
  styleUrls: ['./topics.component.css']
})
export class TopicsComponent implements OnInit {

  public topics;

  constructor(topics: TopicDataService) {
    this.topics = topics.getTopics();
  }

  ngOnInit(): void {
  }

}
