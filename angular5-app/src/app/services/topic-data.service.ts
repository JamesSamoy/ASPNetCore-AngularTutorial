import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class TopicDataService {

  constructor() { }

  getTopics() {
    return [
      {
        name: "A Project",
        image: "Image",
        gitUrl: "url",
        liveUrl: "liveUrl"
      },
      {
        name: "A Project",
        image: "Image",
        gitUrl: "url",
        liveUrl: "liveUrl"
      },
      {
        name: "A Project",
        image: "Image",
        gitUrl: "url",
        liveUrl: "liveUrl"
      },
    ]
  }
}
