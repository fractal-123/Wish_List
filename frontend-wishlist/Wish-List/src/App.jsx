import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';

import Register from './Pages/Auth/Registr';
import Home from './Pages/Home/Home';
import WishList from './Pages/WishList/WishList';
import Login from './Pages/Auth/Login';
import Start from './Pages/Start/Start';
import Game from './Pages/Game/Game';
import Prpfile from './Pages/Profile/Profile';

function App() {
  

  return (
    <Router>
      <Routes>
        <Route path="/" element={<Start />} />
        <Route path="/auth/register" element={<Register />} />
        <Route path="/auth/login" element={<Login />} />
        <Route path="/wishlist" element={<WishList />} />
        <Route path="/home" element={<Home />} />
        <Route path="/game" element={<Game/>} />
        <Route path="/profile" element={<Prpfile/>} />
      </Routes>
    </Router>
  );
}

export default App;
