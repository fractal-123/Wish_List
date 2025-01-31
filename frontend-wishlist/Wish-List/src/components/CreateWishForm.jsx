import { useState, useEffect } from "react";
import { editWish, createWish } from "../services/wish";
import './CreateWishForm.css';

function CreateEditWishForm({ onEdit, selectedWish }) {
  const [formData, setFormData] = useState({
    name: "",
    description: "",
    link: "",
    price: "",
    imagePath: "",
  });

  useEffect(() => {
    if (selectedWish) {
      setFormData({
        name: selectedWish.name || "",
        description: selectedWish.description || "",
        link: selectedWish.link || "",
        price: selectedWish.price || "",
        imagePath: selectedWish.imagePath || "", 
      });
    } else {
      setFormData({
        name: "",
        description: "",
        link: "",
        price: "",
        imagePath: "", 
      });
    }
  }, [selectedWish]);

  const handleChange = (e) => {
    const { name, value } = e.target;
    setFormData((prev) => ({ ...prev, [name]: value }));
  };

  const handleImageChange = (e) => {
    const file = e.target.files[0];
    if (file) {
      setFormData((prev) => ({
        ...prev,
        imagePath: URL.createObjectURL(file),
      }));
    }
  };

  const handleSubmit = async (e) => {
    e.preventDefault();

    try {
      const formDataToSend = new FormData();
      formDataToSend.append("name", formData.name);
      formDataToSend.append("description", formData.description);
      formDataToSend.append("link", formData.link);
      formDataToSend.append("price", formData.price);

      const fileInput = document.querySelector("#fileInput");
      if (fileInput && fileInput.files[0]) {
        formDataToSend.append("photoFile", fileInput.files[0]);
      }

      if (selectedWish?.id) {
        await editWish(selectedWish.id, formDataToSend);
        onEdit(selectedWish.id, formData);
      } else {
        const newWish = await createWish(formDataToSend);
        onEdit(newWish.id, newWish);
      }
    } catch (error) {
      alert("Произошла ошибка при сохранении. Попробуйте снова.");
      console.error(error);
    }
  };

  return (
    <form onSubmit={handleSubmit} className="bg-white w-[70vw] md:w-[30vw] p-6 rounded-lg shadow-md max-h-[90vh] overflow-auto">
      <h3 className="font-bold text-xl mb-7">
        {selectedWish ? "Редактирование желания" : "Создание желания"}
      </h3>

      {/* Название */}
      <div className="mb-4">
        <label className="block text-gray-700 text-sm font-bold mb-2">Название</label>
        <input
          type="text"
          className="shadow border rounded w-full py-2 px-3 text-gray-700"
          name="name"
          placeholder="Добавьте название"
          value={formData.name}
          onChange={handleChange}
        />
      </div>

      {/* Описание */}
      <div className="mb-2">
        <label className="block text-gray-700 text-sm font-bold mb-2">Описание</label>
        <textarea
          rows="5"
          placeholder="Добавьте описание"
          className="shadow border rounded w-full py-2 px-3 text-gray-700"
          value={formData.description}
          onChange={handleChange}
          name="description"
        ></textarea>
      </div>

      {/* Цена */}
      <div className="mb-4">
        <label className="block text-gray-700 text-sm font-bold mb-2">Цена</label>
        <input
          type="number"
          className="shadow border rounded w-full py-2 px-3 text-gray-700"
          name="price"
          placeholder="Добавьте цену"
          value={formData.price}
          onChange={handleChange}
        />
      </div>

      {/* Ссылка */}
      <div className="mb-4">
        <label className="block text-gray-700 text-sm font-bold mb-2">Ссылка</label>
        <input
          placeholder="Добавьте ссылку"
          type="text"
          className="shadow border rounded w-full py-2 px-3 text-gray-700"
          name="link"
          value={formData.link}
          onChange={handleChange}
        />
      </div>

      {/* Загрузка изображения */}
      <div className="mb-4">
        <label className="block text-gray-700 text-sm font-bold mb-2">Изображение</label>
        <div className="relative cursor-pointer">
          {formData.imagePath ? (
            <img 
              src={formData.imagePath} 
              alt="Изображение желания" 
              className="w-full h-48 object-cover rounded-md shadow"
              onClick={() => document.getElementById("fileInput").click()}
            />
          ) : (
            <div 
              className="border-dashed border-2 border-gray-400 w-full h-48 flex items-center justify-center text-gray-500 rounded-md cursor-pointer"
              onClick={() => document.getElementById("fileInput").click()}
            >
              Нажмите, чтобы загрузить изображение
            </div>
          )}
          <input id="fileInput" type="file" className="hidden" onChange={handleImageChange} />
        </div>
      </div>

      {/* Кнопка добавить */}
      <div className="flex items-center justify-between">
        <button
          type="submit"
          className="bg-blue-500 text-sm hover:bg-blue-700 text-white font-bold py-2 px-4 rounded"
        >
          {selectedWish ? "Сохранить изменения" : "Добавить желание"}
        </button>
      </div>
    </form>




    // СТАРАЯ ВЕРСИЯ ФОРМЫ
    // <form onSubmit={handleSubmit} className="w-full flex flex-col gap-3">
    //   <h3 className="font-black text-xl text-center">
    //     {selectedWish ? "Редактирование желания" : "Создание желания"}
    //   </h3>
    //   <Input
    //     name="name"
    //     placeholder="Название"
    //     value={formData.name}
    //     onChange={handleChange}
    //   />
    //   <Textarea
    //     className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
    //     name="description"
    //     size="xs"
    //     placeholder="Описание"
    //     value={formData.description}
    //     onChange={handleChange}
    //   />
    //   <Input
    //     name="price"
    //     type="number"
    //     placeholder="Цена"
    //     value={formData.price}
    //     onChange={handleChange}
    //   />
    //   <Input
    //     name="link"
    //     placeholder="Ссылка"
    //     value={formData.link}
    //     onChange={handleChange}
    //   />
    //   <Button type="submit" colorScheme="teal">
    //     {selectedWish ? "Сохранить изменения" : "Добавить желание"}
    //   </Button>
    // </form>
  );
}

export default CreateEditWishForm;
