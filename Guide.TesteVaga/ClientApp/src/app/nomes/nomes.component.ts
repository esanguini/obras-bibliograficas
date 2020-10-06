import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';

import { INomes } from './nomes';
import { NomesService } from './nomes.service'

@Component({
  selector: 'app-nomes',
  templateUrl: './nomes.component.html',
  styleUrls: ['./nomes.component.css']
})
export class NomesComponent implements OnInit {
  constructor(private fb: FormBuilder, private nomesService: NomesService) { }

  formGroup: FormGroup;
  nomes: INomes[];
  qtdeCampos: number = 0;

  ngOnInit() {
    this.formGroup = this.fb.group({
      nome: '',
    });

    this.carregarNomes()
  }

  carregarNomes() {
    this.nomesService.ListarNomes()
      .subscribe(nomesWebApi => this.nomes = nomesWebApi),
      error => console.error(error);
  }


  excluirNome(nome: INomes) {
    this.nomesService.excluirNomes(nome.id.toString()).subscribe(nome => this.carregarNomes()), error => console.error(error);
  }

  gravar() {
    let nome: INomes = Object.assign({}, this.formGroup.value);
  }

  adicionar() {
    let qtdeCampos = Object.assign({}, this.formGroup.value);

    this.carregarNomes();
  }

}
