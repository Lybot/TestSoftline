import React, { Component } from 'react'

export class Employee extends Component {

    constructor(props) {
        super(props);
        this.state = { employees: [], loading: true };
        this.addPage = this.addPage.bind(this);
        this.getEmployees = this.getEmployees.bind(this);
        this.tableData = this.tableData.bind(this);
        this.deleteEmployee = this.deleteEmployee.bind(this);
    }
    addPage() {
        this.props.history.push('/add');
    }
    componentDidMount() {
        this.getEmployees();
    }
    tableData(employees) {
        if (this.state.loading)
            return(
                <h3>Loading...</h3>)
        else
            return (
                <table className='table table-striped' aria-labelledby="tabelLabel">
                    <thead>
                        <tr>
                            <th>Name</th>
                            <th>Birthday</th>
                            <th>Position</th>
                            <th>Maternity</th>
                            <th>Text</th>
                        </tr>
                    </thead>
                    <tbody>
                        {employees.map(employee =>
                            <tr key={employee.id}>
                                <td>{employee.name}</td>
                                <td>{employee.birthday}</td>
                                <td>{employee.position}</td>
                                <td>{employee.isMaternity}</td>
                                <td>{employee.text}</td>
                                <button className="btn-delete" onClick={() => { this.deleteEmployee(employee)} }>delete</button>
                            </tr>
                        )}
                    </tbody>
                </table>)
    }
    render() {
        return (
            <div>
                <h2>Test</h2>
                {this.tableData(this.state.employees)}
                <button className="btn-primary" onClick={this.addPage}>Add employee</button>
            </div>
        );
    }
    async deleteEmployee(employee) {
        const requestOptions = {
            method: 'DELETE',
            redirect: 'manual',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({ id: employee.id })
        };
        let response = await fetch('/delete/' + employee.id, requestOptions);
        let result = await response.json();
        if (result.success) {
            let newEmployees = this.state.employees.filter(emp => emp != employee);
            this.setState({ employees: newEmployees })
        }
        else {
            alert("Error. Update page");
        }

    }
    async getEmployees() {
        let response = await fetch('/getemployees');
        let employees = await response.json();
        this.setState({ employees: employees, loading: false });
    }
}