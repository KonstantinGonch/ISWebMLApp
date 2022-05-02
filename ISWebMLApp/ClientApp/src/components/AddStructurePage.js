import React, { Component } from 'react';
import { postData } from '../util.js'

export class AddStructurePage extends Component {

    constructor(props) {
        super(props);
        this.state = { name: '', description: '', address: '' };

        this.onSubmitForm = this.onSubmitForm.bind(this);
        this.onChangeAddress = this.onChangeAddress.bind(this);
        this.onChangeDescription = this.onChangeDescription.bind(this);
        this.onChangeName = this.onChangeName.bind(this);
    }

    async onSubmitForm(e) {
        e.preventDefault();

        this.setState({ loading: true });
        const response = await postData("api/structure/save", { name: this.state.name, description: this.state.description, address: this.state.address })

        this.setState({ loading: false });
        alert("Данные сохранены");
    }

    onChangeDescription(e) {
        this.setState({description: e.target.value})
    }

    onChangeName(e) {
        this.setState({ name: e.target.value })
    }

    onChangeAddress(e) {
        this.setState({ address: e.target.value })
    }

    render() {
        return (
            <main role="main" class="container">
                <div class="starter-template">
                    <h1>Введите данные об элементе организационной структуры</h1>
                    <form onSubmit={this.onSubmitForm}>
                        <div class="form-group">
                            <label>Наименование</label>
                            <input type="text" disabled={this.state.loading} class="form-control" rows="5" value={this.state.name} onChange={this.onChangeName}></input>
                        </div>
                        <div class="form-group">
                            <label>Адрес</label>
                            <input type="text" disabled={this.state.loading} class="form-control" rows="5" value={this.state.address} onChange={this.onChangeAddress}></input>
                        </div>
                        <div class="form-group">
                            <label for="exampleFormControlTextarea1">Описание</label>
                            <textarea disabled={this.state.loading} class="form-control" id="exampleFormControlTextarea1" rows="5" value={this.state.description} onChange={this.onChangeDescription}></textarea>
                        </div>
                        <div class="form-group">
                            <button className="btn btn-primary" type="submit" disabled={this.state.loading}>
                                {this.state.loading && <div class="spinner-border text-light" role="status">
                                    <span class="sr-only">Загрузка...</span>
                                </div>}
                                {!this.state.loading && "Сохранить"}
                            </button>
                        </div>
                    </form>
                </div>
            </main>
        );
    }
}
