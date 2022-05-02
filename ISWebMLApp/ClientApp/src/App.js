import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import './custom.css'
import { StructurePage } from './components/StructurePage';
import { AddStructurePage } from './components/AddStructurePage';

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
        <Layout>
            <Route exact path='/' component={StructurePage} />
            <Route exact path='/addStructure' component={AddStructurePage} />
      </Layout>
    );
  }
}
