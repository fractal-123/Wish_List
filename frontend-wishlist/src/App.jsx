import { Textarea, Input, Button } from '@chakra-ui/react';
import './style/App.css';


function App() {

  return <section>
    <div>
      <form>
        <h3>Cоздание заметки</h3>
        <Input placeholder = "Название "></Input>
        <Textarea placeholder = "Описание"></Textarea>
        <Button> Создать </Button>
      </form>
    </div>
  </section>

}

export default App;
