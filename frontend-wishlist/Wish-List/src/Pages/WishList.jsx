import { Button, Stack } from '@chakra-ui/react';
import Wish from "../components/Wish"; // Проверьте, что это соответствует структуре папок
import Modal from "../Modal/Modal";
import './WishList.css';
import { useEffect, useState } from 'react';
import { fetchWish, createWish } from '../services/wish';
import Filters from '../components/Filter';
import { Reorder } from 'framer-motion';
import { Link } from 'react-router-dom';


function WishList() {
  const [wishs, setWish] = useState([]);
  const [filter, setFilter] = useState({
    search: "",
    sortItem: "date",
    sortOrder: "desc",

  });
  const handleEditWish = (id, updatedData) => {
    setWish((prevWishs) =>
      prevWishs.map((wish) =>
        wish.id === id ? { ...wish, ...updatedData } : wish
      )
    );
    setModalActive(false); // Закрываем модальное окно
  };


  const [loading, setLoading] = useState(true);
  useEffect(() => {
    const fetchData = async () => {
      setLoading(true);
      const wishs = await fetchWish();
      setWish(wishs);
      setLoading(false);
    };

    fetchData();
  }, []);


  const onCreate = async (wish) => {
    await createWish(wish)
    let wishs = await fetchWish(filter)
    setWish(wishs);

  };

  const [selectedWish, setSelectedWish] = useState(null);
  const [modalActive, setModalActive] = useState(false);
  const handleEdit = (wish) => {
    setSelectedWish(wish);
    setModalActive(true);
  };
  return (

    <div  >
      <div>
        <header className='bg-slate-500 w-full h-14'>
          <ul className="flex gap-3">
            <li><Link to="/home">Главная</Link></li>
            <li><Link to="/wishlist">Wish List</Link></li>
          </ul>
        </header>
      </div>
      <div className="bg-wishlist">
        <Reorder.Group className='left-list' axis='y' values={wishs} onReorder={setWish}  >
          {wishs.map((n) => (
            <Reorder.Item key={n.id} value={n} whileDrag={{ scale: 1.1 }} >
              <Wish
                id={n.id}
                name={n.name}
                description={n.description}
                link={n.link}
                price={n.price}
                created={n.created}
                setSelectedWish={setSelectedWish} // Передаем setSelectedWish
                setModalActive={setModalActive}   // Также передаем setModalActive
              />
            </Reorder.Item>
          ))}
        </Reorder.Group >

        <div className='click' >
          <Button
            border="1px solid gray"
            className="open-button"
            onClick={() => {
              setSelectedWish(null); // Очищаем выбранное желание
              setModalActive(true); // Открываем модальное окно
            }}
          >
            Добавить
          </Button>
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

        <Modal
          active={modalActive}
          setActive={setModalActive}
          selectedWish={selectedWish}
          onEdit={handleEditWish} // Передаем метод обновления
        />

      </div>
    </div>
  );
}

export default WishList;