import { Component, ViewChild, ElementRef } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { IdpService } from 'src/app/service/idp.service';

@Component({
  selector: 'app-homepage',
  templateUrl: './homepage.component.html',
  styleUrls: ['./homepage.component.css']
})
export class HomepageComponent {
  // model: IdpCreateDto = {
  //     name: '',
  //     userId: 0,
  //     year: new Date(),
  // }

  // idps: IdpViewDto[] | null = null;

  // userId: number | null = null;

  // formData = new FormData();

  // constructor(
  //     private idpService: IdpService,
  //     private route: ActivatedRoute,
  //     private router: Router) { }

  // /**
  //  * Fetches all idps from the server and stores them in the idps
  //  * property. If an error occurs, an alert is shown.
  //  */
  // ngOnInit(): void {
  //     this.idpService.getAll().subscribe({
  //         next: (idps) => {
  //             this.idps = idps;
  //         },
  //         error: (error) => {
  //             console.error(error);
  //             alert("Error loading idps");
  //         }
  //     });


  //     this.userId = this.route.snapshot.params['id'];

  //     this.idpService.getById(this.userId as number).subscribe({
  //         next: (product: IdpViewDto) => {
  //             this.model.name = product.name;
  //             this.model.userId = product.userId;
  //             this.model.year = product.year;
  //         }
  //     })
  // }

  // saveData() {
  //     this.formData.append("name", this.model.name);
  //     this.formData.append("id", this.model.userId.toString());
  //     this.formData.append("year", this.model.year.toString());

  //     this.idpService.create(this.formData).subscribe({
  //         next: () => {
  //             alert("Product created successfully");
  //             return this.router.navigate(['admin', 'products']);
  //         },
  //         error: (error) => {
  //             console.error(error);
  //             alert("Error creating product");
  //         }
  //     })
  // }

}
