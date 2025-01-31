import { Button } from '@chakra-ui/react';
import Wish from "../../components/Wish";
import Modal from "../../Modal/Modal";
import './WishList.css';
import { useEffect, useState } from 'react';
import { fetchWish, createWish } from '../../services/wish';
import Filters from '../../components/Filter';
import { Reorder } from 'framer-motion';
import { Link } from 'react-router-dom';
import { useNavigate } from "react-router-dom";

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

  const navigate = useNavigate();
  const [loading, setLoading] = useState(true);
  useEffect(() => {
    const fetchData = async () => {
      setLoading(true);
      const wishs = await fetchWish(navigate);
      setWish(wishs);
      setLoading(false);
    };

    fetchData();
  }, [navigate]);

  const onCreate = async (wish) => {
    await createWish(wish)
    let wishs = await fetchWish(filter)
    setWish(wishs);

  };
  const handleEdit = (wish) => {
    setSelectedWish(wish);
    setModalActive(true);
  };

  const handleDelete = (wishId) => {
    setWish((prevWishes) => prevWishes.filter((wish) => wish.id !== wishId));
  };

  const [selectedWish, setSelectedWish] = useState(null);
  const [modalActive, setModalActive] = useState(false);

  return (
    <div className="page-container">
      <header className="vertical-header">
        <ul className="header-menu">

          <li><button class="buttonStyle">
            <Link to="/home">Главная</Link>
          </button></li>

          <li><button button class="buttonStyle">
            <Link to="/wishlist">Wish List</Link>
            </button></li>
        </ul>

      </header>

      <div className="content-container">
        <Reorder.Group className="list-container" axis="y" values={wishs} onReorder={setWish}>
          {wishs.map((n) => (
            <Reorder.Item key={n.id} value={n} whileDrag={{ scale: 1.1 }}>
              <Wish
                id={n.id}
                name={n.name}
                description={n.description}
                link={n.link}
                price={n.price}
                created={n.created}
                imagePath={n.imagePath}  // Передаем картинку
                setSelectedWish={setSelectedWish}
                setModalActive={setModalActive}
                onDelete={handleDelete}
              />
            </Reorder.Item>
          ))}
        </Reorder.Group>

        <div className="center-controls">
          <button
            className="open-button "
            border="1px solid gray"
            onClick={() => {
              setSelectedWish(null);
              setModalActive(true);
            }}
          >
            Добавить
          </button>
          <Filters filter={filter} setFilter={setFilter} />
        </div>

        <Reorder.Group className="list-container" axis="y" values={wishs} onReorder={setWish}>
          {wishs.map((n) => (
            <Reorder.Item key={n.id} value={n} whileDrag={{ scale: 1.1 }}>
              <Wish
                id={n.id}
                name={n.name}
                description={n.description}
                link={n.link}
                price={n.price}
                created={n.created}
                setSelectedWish={setSelectedWish} // Передаем setSelectedWish
                setModalActive={setModalActive}
                onDelete={handleDelete}   // Также передаем setModalActive
              />
            </Reorder.Item>
          ))}
        </Reorder.Group>
      </div>

      <Modal
        active={modalActive}
        setActive={setModalActive}
        selectedWish={selectedWish}
        onEdit={selectedWish ? handleEditWish : onCreate} // Передаем метод обновления
      />
    </div>
  );
}

export default WishList;
