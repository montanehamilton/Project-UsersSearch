import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'demodata',
    templateUrl: './demodata.component.html'
})
export class DemoDataComponent {
    public hasData: Boolean;
    private http: Http;
    private baseUrl: string;
    public hasError: Boolean;
    public isComplete: Boolean;
    
    constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {
        this.hasData = false;
        this.http = http;
        this.baseUrl = baseUrl;
        this.hasError = false;
        this.isComplete = false;

        this.http.get(this.baseUrl + 'api/Users/DemoDataStatus').subscribe(result => {
            this.hasData = result.json() as Boolean;
        }, error => {
            console.error(error);
            this.hasError = true;
        });
    }

    public onClick() {
        this.hasError = false;

        this.http.post(this.baseUrl + 'api/Users/DemoData', {}).subscribe(result => {
            this.hasData = true;
            this.isComplete = true;

            var that = this;
            setTimeout(function () {
                that.isComplete = false;
            }, 3000);
        }, error => {
            console.error(error);
            this.hasError = true;
        });
    }

    public getButtonText(): string{
        return this.hasData ? "Reset Data" : "Add Data";
    }
}
