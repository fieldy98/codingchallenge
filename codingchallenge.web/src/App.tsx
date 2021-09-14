import React from 'react';
import { Container, Menu } from 'semantic-ui-react';
import { NotificationForm } from './Components/Home'

function App() {
  return (
    <div>
      <Menu widths={1} inverted>
        <Menu.Item>
          Supervisor Notification Form
        </Menu.Item>
      </Menu>
      <Container>
        <NotificationForm />
      </Container>
    </div>
  );
}

export default App;
