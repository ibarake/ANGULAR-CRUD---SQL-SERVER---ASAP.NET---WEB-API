import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { platos } from '../models/platos'
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class PlatoService {

  constructor(private http:HttpClient) { }

  url:string = "https://localhost:44354/api/platos";

  getPlato(){
    return this.http.get(this.url);
  }

  addPlato(plato:platos):Observable<platos>{
    return this.http.post<platos>(this.url, plato);
  }

  updatePlato(id:number, plato:platos):Observable<platos>{
    return this.http.put<platos>(this.url + `/${id}`, platos);
  }

  deletePlato(id:number){
    return this.http.delete(this.url + `/${id}`);
  }
}
