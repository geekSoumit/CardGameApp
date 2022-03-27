import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { Type } from '@angular/core';
import { TestBed, async, ComponentFixture } from '@angular/core/testing';

import { CardGameComponent } from './card-game.component';

describe('Card game component', () => {
    let httpTestingController: HttpTestingController;
    let fixture: ComponentFixture<CardGameComponent>;
    let component: CardGameComponent;


    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [CardGameComponent],
            imports: [HttpClientTestingModule],
        })
            .compileComponents();
    }));

    beforeEach(() => {
        fixture = TestBed.createComponent(CardGameComponent);
        httpTestingController = TestBed.get(HttpTestingController as Type<HttpTestingController>);
        component = fixture.componentInstance;
    });

    it('should create', () => {
        expect(component).toBeTruthy();
    });

    it('after component creation isEmpty() should return false', () => {
        expect(component.isEmpty()).toBeFalsy();
    });

    it('short() should return sorted cards', () => {
        const arr: string = '6h,rt';
        component.sort(arr);

        httpTestingController.expectOne({ method: 'PUT', url: `/api/card/Sort` });
        httpTestingController.verify();
    });

});