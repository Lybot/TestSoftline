import React, { Component } from 'react'
import DatePicker from 'react-datepicker';
import "react-datepicker/dist/react-datepicker.css"
export class AddEmployee extends Component {
    constructor(props) {
        super(props);
        this.homePage = this.homePage.bind(this);
        this.addRequest = this.addRequest.bind(this);
        this.state = { lastName: '', firstName: '', middleName: '', text: '', birthday: new Date(), position: "Director", maternity: false };
    }
    homePage() {
        this.props.history.push("/");
    }
    deleteNumbers(value: String) {
        return value.replace(/[^A-Za-zА-Яа-яЁё]/ig, "")
    }
    render() {
        return (
            <div>
                <a onClick={this.homePage} className="btn-back">&#8249; Back</a>
                <div className="center-div">
                    <form onSubmit={(e) => { this.addRequest(e) }} className="form">
                        <h2 className="form_title">Employee</h2>
                        <div className="form_grup">
                            <label >Last name</label>
                            <input  className="form_input" type="text" value={this.state.lastName} onChange={e => { this.setState({ lastName: this.deleteNumbers(e.target.value) }) }} name="lastname" />
                        </div>
                        <div className="form_grup">
                            <label >First name</label>
                            <input className="form_input" type="text" placeholder=" " value={this.state.firstName} onChange={e => { this.setState({ firstName: this.deleteNumbers(e.target.value) }) }} name="firstname" />
                        </div>
                        <div className="form_grup">
                            <label >Middle name</label>
                            <input className="form_input" type="text" placeholder=" " value={this.state.middleName} onChange={e => { this.setState({ middleName: this.deleteNumbers(e.target.value) }) }} name="middlename" />
                        </div>
                        <div className="form_grup">
                            <label>Birthday</label>
                            <DatePicker selected={this.state.birthday} onChange={e => { this.setState({ birthday: e }) }} showYearDropdown name="date" />
                        </div>
                        <div className="form_grup">
                            <label >Position</label>
                            <select style={{ width: '100%', padding: '5px' }} value={this.state.position} onChange={e => { this.setState({ position: e.target.value }) }} name="position" >
                                <option selected value="Director">Director</option>
                                <option value="Programmer">Programmer</option>
                                <option value="Analyzer">Analyzer</option>
                                <option value="Accountant">Accountant</option>
                                <option value="Cleaner">Cleaner</option>
                            </select>
                        </div>
                        <div className="form_grup">
                            <label >Maternity</label>
                            <select style={{ padding: '5px', marginLeft: '10px' }} value={this.state.position} onChange={e => { this.setState({ position: e.target.value }) }} name="maternity" >
                                <option value={true}>Yes</option>
                                <option selected value={false}>No</option>
                            </select>
                        </div>
                        <div className="form_grup">
                            <label >Text</label>
                            <input className="form_input" type="text" placeholder=" " value={this.state.text} onChange={e => { this.setState({ text: e.target.valueAsDate }) }} name="text" />
                        </div>
                        <input className="btn-primary" type="submit" value="Add employee" />
                    </form>
                </div>
            </div>
        )
    }
    async addRequest(e) {
        e.preventDefault();
        const requestOptions = {
            method: 'POST',
            redirect: 'manual',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({
                firstName: this.state.firstName,
                lastName: this.state.lastName,
                middleName: this.state.middleName,
                position: this.state.position,
                birthday: this.state.birthday,
                text: this.state.text
            })
        };
        let response = await fetch("/add", requestOptions);
        let result = await response.json();
        if (result.success) {
            alert('Success');
            this.homePage();
        }
        else {
           
            alert('Error '+result.message);
        }
        //this.homePage()
    }
}