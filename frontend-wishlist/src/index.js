import React from 'react';
import ReactDOM from 'react-dom';
import App from './App';
import { ChakraProvider } from '@chakra-ui/react';

ReactDOM.createRoot(document.getElementById("root")).render(
    <ChakraProvider>
        <App/>
    </ChakraProvider>
);

