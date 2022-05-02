import React, { Component } from 'react';
import { getData } from '../util';

export class StructurePage extends Component {

    constructor(props) {
        super(props);
        this.state = { structures: [], loading: false };
    }

    async componentDidMount() {
        this.setState({ loading: true });
        const structs = await this.getStructures();
        this.setState({ structures: structs, loading: false })
    }

    async getStructures() {
        return await getData("api/structure/list");
    }

    render() {
        return (
            <div>
                <div class="row d-flex justify-content-center">
                    <div>
                        <h1>Организационная структура</h1>
                    </div>
                </div>
                {this.state.loading &&
                    <div class="d-flex justify-content-center">
                        <div class="spinner-border text-primary list-spinner" role="status">
                            <span class="sr-only">Загрузка...</span>
                        </div>
                    </div>}
                {!this.state.loading &&
                    <div>
                        {this.state.structures.length === 0 && <h2>Информация отсутствует</h2>}
                        <div class="row">
                        </div>
                        <div class="row">
                            <a class="link-primary" href="/addStructure">Добавить</a>
                        </div>
                    </div>}
            </div>
        );
    }
}
