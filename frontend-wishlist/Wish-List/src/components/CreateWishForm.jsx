import { Button, Input, Textarea } from "@chakra-ui/react";
import { useState, useEffect } from "react";
import { editWish, createWish } from "../services/wish"; // Добавил createWish

function CreateEditWishForm({ onEdit, selectedWish  }) {
  const [formData, setFormData] = useState({
    name: "",
    description: "",
    price: "",
    link: "",
  });

  // Обновляем данные формы, если selectedWish изменился
  useEffect(() => {
    if (selectedWish) {
      setFormData({
        name: selectedWish.name || "",
        description: selectedWish.description || "",
        price: selectedWish.price || "",
        link: selectedWish.link || "",
      });
    } else {
      setFormData({
        name: "",
        description: "",
        price: "",
        link: "",
      });
    }
  }, [selectedWish]);

  const handleChange = (e) => {
    const { name, value } = e.target;
    setFormData((prev) => ({ ...prev, [name]: value }));
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    
      if (!selectedWish?.id) {
        return;
      }
    
      try {
        await editWish(selectedWish.id, formData); 
        onEdit(selectedWish.id, formData); 
      } catch (error) {
        
      }
    };

  return (
    <form onSubmit={handleSubmit} className="w-full flex flex-col gap-3">
      <h3 className="font-black text-xl text-center">
        {selectedWish ? "Редактирование желания" : "Создание желания"}
      </h3>
      <Input
        name="name"
        placeholder="Название"
        value={formData.name}
        onChange={handleChange}
      />
      <Textarea
        name="description"
        size="xs"
        placeholder="Описание"
        value={formData.description}
        onChange={handleChange}
      />
      <Input
        name="price"
        type="number"
        placeholder="Цена"
        value={formData.price}
        onChange={handleChange}
      />
      <Input
        name="link"
        placeholder="Ссылка"
        value={formData.link}
        onChange={handleChange}
      />
      <Button type="submit" colorScheme="teal">
        {selectedWish ? "Сохранить изменения" : "Добавить желание"}
      </Button>
    </form>
  );
}

export default CreateEditWishForm;
