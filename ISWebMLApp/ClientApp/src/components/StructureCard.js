import React, { Component } from 'react';
import { getData } from '../util';

export class StructureCard extends Component {

    constructor(props) {
        super(props);
        this.state = {loading: false, machines: []}
    }

    async componentDidMount() {
        this.setState({ loading: true });
        const id = this.props.structure.id;
        const response = await getData("api/machine/list?id=" + id);
        this.setState({ loading: false, machines: response });
    }

    render() {
        return (
            <div class="card mb-4 box-shadow">
                <div class="card-header">
                    <h4 class="my-0 font-weight-normal">{ this.props.structure.name }</h4>
                </div>
                <div class="card-body">
                    {this.state.loading &&
                        <div class="d-flex justify-content-center">
                            <div class="spinner-border text-primary list-spinner" role="status">
                                <span class="sr-only">Загрузка...</span>
                            </div>
                        </div>}
                    {!this.state.loading && <ul class="list-unstyled mt-3 mb-4">
                        {this.state.machines.map(m => <li>{ m.hostName}</li>)}
                    </ul>}
                </div>
                <a class="link-light" href={`/add-machine?id=` + this.props.structure.id}>Добавить</a>
            </div>
        );
    }
}
