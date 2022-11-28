import { Component } from '@angular/core';
import { platos } from './models/platos';
import { PlatoService } from './services/plato.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  plato:platos = new platos();
  datatable:any = [];

  constructor(private platoService:PlatoService){

  }

  ngOnInit(): void{
    this.onDataTable();
  }

  onDataTable(){
    this.platoService.getPlato().subscribe( res => {
      this.datatable = res;
      console.log(res);
    });
  }

  onSetData(select:any){
    this.plato.id = select.id_plato;
    this.plato.nombre = select.nombre;
    this.plato.categoria = select.categoria;
    this.plato.descripcion = select.descripcion;
  }

  onAddData(plato:platos):void{
    this.platoService.addPlato(plato).subscribe(res =>{
      if(res){
        alert(`New plate added: ${plato.nombre}.`)
        this.clear();
        this.onDataTable();
      } else {
        alert("Error! Try again.")
      }
    });
  }

  onUpdateData(plato:platos):void{
    this.platoService.updatePlato(plato.id, plato).subscribe(res =>{
      if(res){
        alert(`Plate updated: ${plato.nombre}.`)
        this.clear();
        this.onDataTable();
      } else {
        alert("Error! Try again.");
      }
    })
  }

  onDeleteData(plato:platos):void{
    this.platoService.deletePlato(plato.id).subscribe(res =>{
      if(res){
        alert(`Plate deleted: ${plato.nombre}.`)
        this.clear();
        this.onDataTable();
      } else {
        alert("Error! Try again.");
      }
    })
  }

  clear(){
    this.plato.id = 0;
    this.plato.nombre = "";
    this.plato.categoria = "";
    this.plato.descripcion = "";
  }

}
