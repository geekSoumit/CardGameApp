import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';

@Component({
  selector: 'app-card-game',
  templateUrl: './card-game.component.html'
})
export class CardGameComponent {
    cards: string[] = [];
    isError: boolean = false;

    constructor(private http:HttpClient){}

    isEmpty() {
        return this.cards.length !== 0;
    }


    sort(deck: string){

        let cards = deck.split(',');

        cards = cards.map(card => card.trim()).filter(card => card !== '');
        this.cards = [];

        this.http.put<string[]>("/api/card/Sort", cards).subscribe(
            res => { 
                this.cards.push(...res);
                this.isError = false;
            },
            error => this.isError = true
        );
    }
}
