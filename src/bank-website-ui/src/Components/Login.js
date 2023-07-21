import React from 'react';
import axios from 'axios';
import { UserAddOutlined, UnlockOutlined,GoogleOutlined,FacebookOutlined,InstagramOutlined } from '@ant-design/icons'
import { Space, Typography } from 'antd';
import { Button, Checkbox, Form, Input } from 'antd';
const { Text, Link } = Typography;


const onFinish =async (values) => {
  console.log('Success:', values);
  console.log(process.env.REACT_APP_LOGIN_URL)
     const request = {
      Name: values.username,
      Password: values.password
    }
    await axios.post(process.env.REACT_APP_LOGIN_URL, request)
      .then(response => {
        console.log(response)
      }).catch()
};

const onFinishFailed = (errorInfo) => {
  console.log('Failed:', errorInfo);
  
};
const Login = () => (
    <div style={{ display: 'flex', alignItems: 'center', height: '100vh',backgroundColor: '#43ddb7'}}>
  <Form 
    name="basic"
    labelCol={{
      span: 8,
    }}
    wrapperCol={{
      span: 16,
    }}
    style={{  
        paddingInline: '20px',
        paddingBlock:"60px", 
        backgroundColor: 'white',
        borderRadius: '50px',
        marginLeft: '15vh'
    }}
    initialValues={{
      remember: true,
    }}
    onFinish={onFinish}
    onFinishFailed={onFinishFailed}
    autoComplete="off"
  >
    <Form.Item
      label="Username"  
      name="username"
      rules={[
        {
          required: true,
          message: 'Please input your username!',
        },
      ]}
    >
      <Input />
    </Form.Item>

    <Form.Item
      label="Passord"
      name="password"
      rules={[
        {
          required: true,
          message: 'Please input your password!',
        },
      ]}
    >
      <Input.Password />
    </Form.Item>

    <Form.Item
      name="remember"
      valuePropName="checked"
      style={{ display: 'flex', justifyContent: 'center', alignItems: 'center'}}
      wrapperCol={{
        offset: 8,
        span: 16,
      }}
    >
      <Checkbox>Remember me</Checkbox>
    </Form.Item>

    <Form.Item style={{ display: 'flex', justifyContent: 'center', alignItems: 'center'}}>
      <Button type="primary" htmlType="submit"  >
        Submit
      </Button>
    </Form.Item>

    <Form.Item >
    <Text strong>Ant Design (strong)</Text>
      <Button type="link" href='/register' >
        Register
      </Button>
    </Form.Item>


<div style={{fontSize:"28px", display: 'flex', alignItems: 'center',paddingInline:"15px"}}>
    <GoogleOutlined />
    <FacebookOutlined />
    <InstagramOutlined />
    
</div>

  </Form>

  </div>
);
export default Login;

