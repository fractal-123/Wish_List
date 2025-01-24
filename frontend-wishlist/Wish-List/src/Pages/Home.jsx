import { React } from 'react';
import { Link} from 'react-router-dom';


function Home() {

    return (
        
        <div>
            <header className='bg-slate-500 w-full h-14'>
                <ul className="flex gap-3">
                    <li><Link to="/home">Главная</Link></li>
                    <li><Link to="/wishlist">Wish List</Link></li>
                </ul>
            </header>
        </div>
       
        
    )
}



export default Home;