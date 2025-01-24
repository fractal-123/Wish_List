import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';

import Register from './Pages/Registr';
import Home from './Pages/Home';
import WishList from './Pages/WishList';
import Login from './Pages/Login';
import Start from './Pages/Start';


function App() {
  

  return (
    <Router>
      <Routes>
        <Route path="/" element={<Start />} />
        <Route path="/auth/register" element={<Register />} />
        <Route path="/auth/login" element={<Login />} />
        <Route path="/wishlist" element={<WishList />} />
        <Route path="/home" element={<Home />} />
      </Routes>
    </Router>
  );
}

export default App;
