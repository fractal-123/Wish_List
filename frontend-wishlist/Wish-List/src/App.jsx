
import './App.css'
import CreateWishForm from './components/CreateWishForm';
import Wish from './components/Wish';

function App() {
  

  return (
    <section className='p-8 flex flex-row jusify-start items-start gap-12'>
      <div className='flex flex-col w-1/3 gap-10'>
        <CreateWishForm/>
        <div>Фильтры</div>
      </div>
      <ul className='flex flex-col gap-5 w-1/2'>
        <li>
          <Wish/>
        </li>
        <li>
          <Wish/>
        </li>
        <li>
          <Wish/>
        </li>
      </ul>
      
    </section>
  )
}

export default App;
