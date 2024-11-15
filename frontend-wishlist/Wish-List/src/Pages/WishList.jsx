import { Button,  Stack} from '@chakra-ui/react';
import Wish from "../components/Wish"; // Проверьте, что это соответствует структуре папок
import Modal from "../Modal/Modal";
import './WishList.css';
import { useEffect, useState } from 'react';
import { fetchWish, createWish } from '../services/wish';
import Filters from '../components/Filter';
import { Reorder } from 'framer-motion';


function WishList() {
    const [wishs, setWish] = useState([]);
    const [filter, setFilter] = useState({
      search: "",
      sortItem: "date",
      sortOrder: "desc",
  
    });
  
    useEffect(() => {
      const fetchData = async () => {
        let wishs = await fetchWish(filter);
        setWish(wishs);
      };
  
      fetchData();
    }, [filter]);
  
    const onCreate = async (wish) => {
      await createWish(wish)
      let wishs = await fetchWish(filter)
      setWish(wishs);
  
    };
  
  
    const [modalActive, setModalActive] = useState(false);
  return (
    <div className="bg-wishlist" >

        <Reorder.Group className='left-list' axis='y' values={wishs} onReorder={setWish}  >
          {wishs.map((n) => (
            <Reorder.Item key={n.id} value={n} whileDrag={{ scale: 1.1 }} >
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
        <Button 
        border='1px solid gray'
        className='open-button' onClick={() => setModalActive(true)}>Добавить</Button>
        <Filters filter={filter} setFilter={setFilter} />
      </div>

      <ul className='right-list' >
        {wishs.map((n) => (
          <li key={n.id}  >
            <Wish
              name={n.name}
              description={n.description}
              price={n.price}
              created={n.created}
            />
          </li>
        ))}
      </ul>

      <Modal active={modalActive} setActive={setModalActive} onCreate={onCreate} />
    </div>
  );
}

export default WishList;