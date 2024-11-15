import { BrowserRouter as Router, Routes, Route, Link } from 'react-router-dom';

import Home from './Pages/Home';
import WishList from './Pages/WishList';

function App() {


  return (
    <Router>
      <div>
        <header className='bg-slate-500 w-full h-14'>
          <ul className="flex gap-3">
            <li><Link to="/home">Главная</Link></li>
            <li><Link to="/wishlist">Wish List</Link></li>
          </ul>
        </header>

        <Routes>
          <Route path="/home" element={<Home />} />
          <Route
            path="/wishlist"
            element={
              <WishList/>
            }
          />
        </Routes>
      </div>
    </Router>
  );
}

export default App;
