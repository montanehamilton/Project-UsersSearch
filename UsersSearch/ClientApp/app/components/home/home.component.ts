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

    public forecasts: WeatherForecast[];

    constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {
        this.isSearching = false;
        this.hasSearched = false;
        this.usersFound = [];

        http.get(baseUrl + 'api/SampleData/WeatherForecasts').subscribe(result => {
            this.forecasts = result.json() as WeatherForecast[];
        }, error => console.error(error));
    }
    
    public onSearch(currentSearchText: string) {
        this.hasSearched = true;
        this.isSearching = true;
        this.usersFound = [
            new User(
                "Montane",
                "Hamilton",
                new Date(1975, 4, 6),
                new Address(
                    "5258 N Grey Hawk Dr",
                    "",
                    "Lehi",
                    "UT",
                    "84043"),
                [
                    new Interest("Model Railroading"),
                    new Interest("Programming")
                ]
            ),
            new User(
                "Ollie",
                "Hamilton",
                new Date(2005, 4, 6),
                new Address(
                    "513 27th St. No.",
                    "",
                    "Great Falls",
                    "MT",
                    "59401"),
                [
                    new Interest("Religion"),
                    new Interest("Birth")
                ]
            )
        ]
        this.isSearching = false;
    }

    public onChange(currentSearchText: string) {
        if (!currentSearchText) {
            this.isValid = false;
        }

        this.isValid = currentSearchText.length > 0;
    }

    public getAge(birthDate: Date): Number {
        return new Date().getFullYear() - birthDate.getFullYear();
    }
}

interface WeatherForecast {
    dateFormatted: string;
    temperatureC: number;
    temperatureF: number;
    summary: string;
}

export class User {
    constructor(
        public firstName: string,
        public lastName: string,
        public birthDate: Date,
        public address: Address,
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