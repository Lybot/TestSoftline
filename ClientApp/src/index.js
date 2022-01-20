import 'bootstrap/dist/css/bootstrap.css';
import React from 'react';
import ReactDOM from 'react-dom';
import { BrowserRouter, Route, Switch } from 'react-router-dom';
import registerServiceWorker from './registerServiceWorker';
import { Employee } from './components/Employees';
import { AddEmployee } from './components/AddEmployee';
import './custom.css'
const baseUrl = document.getElementsByTagName('base')[0].getAttribute('href');
const rootElement = document.getElementById('root');

ReactDOM.render(
    <BrowserRouter basename={baseUrl}>
        <Switch>
            <Route exact path="/" component={Employee} />
            <Route path="/add" component={AddEmployee} />
        </Switch>
    </BrowserRouter>,
    rootElement);

//registerServiceWorker();

