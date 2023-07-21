import axios from 'axios';
import {
  AutoComplete,
  Button,
  Cascader,
  Checkbox,
  Col,
  Form,
  Input,
  InputNumber,
  Row,
  Select,
} from 'antd';
import { useState } from 'react';


const { Option } = Select;
const residences = [
  {
    value: 'zhejiang',
    label: 'Zhejiang',
    children: [
      {
        value: 'hangzhou',
        label: 'Hangzhou',
        children: [
          {
            value: 'xihu',
            label: 'West Lake',
          },
        ],
      },
    ],
  },
  {
    value: 'jiangsu',
    label: 'Jiangsu',
    children: [
      {
        value: 'nanjing',
        label: 'Nanjing',
        children: [
          {
            value: 'zhonghuamen',
            label: 'Zhong Hua Men',
          },
        ],
      },
    ],
  },
];
const formItemLayout = {
  labelCol: {
    xs: {
      span: 24,
    },
    sm: {
      span: 8,
    },
  },
  wrapperCol: {
    xs: {
      span: 24,
    },
    sm: {
      span: 16,
    },
  },
};
const tailFormItemLayout = {
  wrapperCol: {
    xs: {
      span: 24,
      offset: 0,
    },
    sm: {
      span: 16,
      offset: 8,
    },
  },
};
const Register = () => {
  const [form] = Form.useForm();

  const onFinish = async (values) => {
    console.log('Received values of form: ', values);

    console.log(process.env.REACT_APP_REGISTER_URL)
    const request = {
      Name: values.username,
      Password: values.password,
      Phone:values.phone,
      Email:values.email
    }
    console.log(request);
    await axios.post(process.env.REACT_APP_REGISTER_URL, request)
      .then(response => {
        console.log(response)
      }).catch()
  };
  const prefixSelector = (
    <Form.Item name="prefix" noStyle>
      <Select
        style={{
          width: 70,
        }}
      >
        <Option value="86">+86</Option>
        <Option value="87">+87</Option>
      </Select>
    </Form.Item>
  );

  const [autoCompleteResult, setAutoCompleteResult] = useState([]);
  const onWebsiteChange = (value) => {
    if (!value) {
      setAutoCompleteResult([]);
    } else {
      setAutoCompleteResult(['.com', '.org', '.net'].map((domain) => `${value}${domain}`));
    }
  };
  const websiteOptions = autoCompleteResult.map((website) => ({
    label: website,
    value: website,
  }));
  return (
    <div style={{ background: "#43ddb7", display: 'flex', alignItems: 'center', height: '100vh' }}>
      <Form
        {...formItemLayout}
        form={form}
        name="register"
        onFinish={onFinish}
        initialValues={{
          prefix: '+90',
        }}
        style={{

          paddingInline: '28px',
          paddingBlock: "20px",
          backgroundColor: 'white',
          borderRadius: '50px',
          marginLeft: '15vh'

        }}
        scrollToFirstError
      >
        <Form.Item
          name="email"
          label="E-mail"
          rules={[
            {
              type: 'email',
              message: 'The input is not valid E-mail!',
            },
            {
              required: true,
              message: 'Please input your E-mail!',
            },
          ]}
        >
          <Input />
        </Form.Item>

        <Form.Item
          name="password"
          label="Password"
          rules={[
            {
              required: true,
              message: 'Please input your password!',
            },
          ]}
          hasFeedback
        >
          <Input.Password />
        </Form.Item>

        <Form.Item
          name="confirm"
          label="Confirm Password"
          dependencies={['password']}
          hasFeedback
          rules={[
            {
              required: true,
              message: 'Please confirm your password!',
            },
            ({ getFieldValue }) => ({
              validator(_, value) {
                if (!value || getFieldValue('password') === value) {
                  return Promise.resolve();
                }
                return Promise.reject(new Error('The new password that you entered do not match!'));
              },
            }),
          ]}
        >
          <Input.Password />
        </Form.Item>

        <Form.Item
          name="username"
          label="Username"
          tooltip="What do you want others to call you?"
          rules={[
            {
              required: true,
              message: 'Please input your nickname!',
              whitespace: true,
            },
          ]}
        >
          <Input />
        </Form.Item>

        <Form.Item
          name="phone"
          label="Phone Number"
          rules={[
            {
              required: true,
              message: 'Please input your phone number!',
            },
          ]}
        >
          <Input
            addonBefore={prefixSelector}
            style={{
              
            }}
          />
        </Form.Item>



        <Form.Item label="Captcha" extra="We must make sure that your are a human.">
          <Row gutter={8}>
            <Col span={12}>
              <Form.Item
                name="captcha"
                noStyle
                rules={[
                  {
                    required: true,
                    message: 'Please input the captcha you got!',
                  },
                ]}
              >
                <Input />
              </Form.Item>
            </Col>
            <Col span={12}>
              <Button>Get captcha</Button>
            </Col>
          </Row>
        </Form.Item>

        <Form.Item
          name="agreement"
          valuePropName="checked"
          rules={[
            {
              validator: (_, value) =>
                value ? Promise.resolve() : Promise.reject(new Error('Should accept agreement')),
            },
          ]}
          {...tailFormItemLayout}
        >
          <Checkbox>
            I have read the <a href="">agreement</a>
          </Checkbox>
        </Form.Item>
        
        <Form.Item {...tailFormItemLayout}>
          <Button type="primary" htmlType="submit">
            Register
          </Button>
        </Form.Item>

        <Form.Item {...tailFormItemLayout}>
          If you have account 
          <Button type="dashed" href="/">
            Login
          </Button>
        </Form.Item>

      </Form>
    </div>
  );
};
export default Register;