import { Button, Input } from '@chakra-ui/react';
import './App.css'
import Wish from './components/Wish';
import Modal from "./Modal/Modal";
import { useEffect, useState } from 'react';
import { fetchWish, createWish } from '../services/wish';
import Filters from './components/Filter';
import {Reorder} from 'framer-motion';

function App() {
  const[wishs, setWish] =  useState([]);
  const[filter,setFilter] = useState({
    search: "",
    sortItem: "date",
    sortOrder: "desc",

    });

  useEffect(() => {
    const fetchData = async () => {
      let wishs  = await fetchWish(filter);
      setWish(wishs);
    };

    fetchData();
  }, [filter]);
  
    const onCreate = async (wish) => {
    await createWish(wish)
    let wishs = await fetchWish(filter)
    setWish(wishs);
   
   };

  
  const[modalActive, setModalActive] = useState(true);

  

  return (
    
    <section className='p-8 flex flex-row z-10'>
      
      <Reorder.Group className='left-list' axis='y' values={wishs} onReorder={setWish} >
        {wishs.map((n) => (
          <Reorder.Item key ={n.id} value={n} whileDrag={{scale: 1.1}} >
            <Wish 
              name={n.name} 
              description={n.description} 
              price={n.price}
              created={n.created}
            />
          </Reorder.Item>
        ))}
      </Reorder.Group >

      <div className='click' >
        <Button className='open-button' onClick={() => setModalActive(true)}>Открыть</Button>
        <Filters filter={filter} setFilter ={setFilter} />
      </div>

      <ul className='right-list'>
        {wishs.map((n) => (
          <li key ={n.id}  >
            <Wish 
              name={n.name} 
              description={n.description} 
              price={n.price}
              created={n.created}
            />
          </li>
        ))}
      </ul>

      <Modal active={modalActive} setActive={setModalActive}  onCreate = {onCreate}/>  
      
    </section>
    
  );
}

export default App;
