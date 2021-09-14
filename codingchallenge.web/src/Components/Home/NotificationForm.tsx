import { useEffect, useState } from 'react';
import { useForm } from 'react-hook-form'
import { Form, Message } from 'semantic-ui-react';

const NotificationForm = () => {
    const [supervisorList, setSupervisorList] = useState([])
    const { register, handleSubmit, formState: { errors } } = useForm();

    useEffect(() => {
        supervisors();

        async function supervisors() { 
            const response = await fetch('http://localhost:5000/api/supervisors') 
            const data = await response.json()
    
            setSupervisorList(data);
        }
    }, [])

    const onSubmit = (data: any) => {
        const notificationPost = {
            method: 'POST',
            headers: { 'Content-Type': 'application/json'},
            body: JSON.stringify(data)
        };

        fetch('http://localhost:5000/api/submit', notificationPost)
            .then(response => response.json())
            .then((data:any) => console.log(data));
    }

    return (
        <div>
            <Form onSubmit={handleSubmit(onSubmit)} id='notificationForm'>
                <Form.Group widths='equal'>
                    <Form.Field>
                        <label>First Name</label>
                        <input placeholder="First Name" type='text' {...register("firstName", { required: true, pattern: /^[\\sa-zA-Z'-]*$/i })} />
                        {
                            errors.firstName &&
                            <Message negative>
                                <p>Please enter a valid first name</p>
                            </Message>
                        }
                    </Form.Field>
                    <Form.Field>
                        <label>Last Name</label>
                        <input placeholder="Last Name" type='text' {...register('lastName', { required: true, pattern: /^[\\sa-zA-Z'-]*$/i })} />
                        {
                            errors.lastName &&
                            <Message negative>
                                <p>Please enter a valid last name</p>
                            </Message>
                        }
                    </Form.Field>
                </Form.Group>
                <Form.Group widths='equal'>
                    <Form.Field>
                        <label>Email</label>
                        <input placeholder="example@example.com" type='email' {...register('email')} />
                        {
                            errors.email &&
                            <Message negative>
                                <p>Please enter a valid email</p>
                            </Message>
                        }
                    </Form.Field>
                    <Form.Field>
                        <label>Phone Number</label>
                        <input placeholder="555-555-5555" type='tel' {...register('phoneNumber', { pattern: /[0-9]{3}-[0-9]{3}-[0-9]{4}/i})} />
                        {
                            errors.phoneNumber &&
                            <Message negative>
                                <p>Please enter a valid phone number</p>
                            </Message>
                        }
                    </Form.Field>
                </Form.Group>
                <Form.Group>
                    <Form.Field>
                        <div className='ui radio checkbox'>
                            <input id='email' type='radio' defaultChecked value='email' {...register('notificationType')} />
                            <label>Email</label>
                        </div>
                    </Form.Field>
                    <Form.Field>
                        <div className='ui radio checkbox'>
                            <input id='phone' type='radio' value='phone' {...register('notificationType')} />
                            <label>Phone</label>
                        </div>
                    </Form.Field>
                </Form.Group>
                <Form.Field>
                    <label>Supervisor</label>
                    <select className="ui fluid dropdown" {...register('supervisor')}>
                        <option hidden value="">Supervisor</option>
                        {supervisorList && supervisorList.map((o:any) => <option key={o.id} value={o.supervisor}>{o.supervisor}</option>)}
                    </select>
                </Form.Field>
                <Form.Field>
                <button className='ui button' type='submit' id='submit'>Submit</button>
                </Form.Field>
            </Form> 
        </div>
    )
}

export { NotificationForm }
