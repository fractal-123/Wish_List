import ReactDOM from 'react-dom/client';
import App from './App.jsx';
import Home from './Pages/Home.jsx';
import './index.css'
import { ChakraProvider } from '@chakra-ui/react'

ReactDOM.createRoot(document.getElementById('root')).render(
  <ChakraProvider>
    <App />
  </ChakraProvider>
);
