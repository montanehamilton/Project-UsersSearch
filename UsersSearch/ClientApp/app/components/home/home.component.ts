import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'home',
    templateUrl: './home.component.html'
})
export class HomeComponent {
    public isSearching: Boolean;
    public hasSearched: Boolean;
    public usersFound: User[];
    public isValid: Boolean;
    private http: Http;
    private baseUrl: string;
    public hasError: Boolean;
    
    constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {
        this.isSearching = false;
        this.hasSearched = false;
        this.hasError = false;
        this.usersFound = [];
        this.http = http;
        this.baseUrl = baseUrl;
    }

    public onSearch(currentSearchText: string) {
        this.hasSearched = true;
        this.isSearching = true;
        this.hasError = false;

        this.http.get(this.baseUrl + 'api/Users/All').subscribe(result => {
            this.usersFound = result.json() as User[];
            this.isSearching = false;
        }, error => {
            console.error(error);
            this.isSearching = false;
            this.hasError = true;
        });
    }

    public onChange(currentSearchText: string) {
        if (!currentSearchText) {
            this.isValid = false;
        }

        this.isValid = currentSearchText.length > 0;
    }
}

export class User {
    constructor(
        public firstName: string,
        public lastName: string,
        public age: Number,
        public avatarUrl: string,
        public addresses: Address[],
        public interests: Interest[]
    ) {
    }
}

export class Address {
    constructor(
        public lineOne: string,
        public lineTwo: string,
        public city: string,
        public adminArea: string,
        public postalCode: string,
    ) {
    }
}

export class Interest {
    constructor(
        public description: string
    ) {
    }
}