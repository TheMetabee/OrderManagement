<script>
  import { ref } from 'vue'

  const customerName = ref("");
  const productName = ref("");
  const quantity = ref(0);

  const addOrder = (() => {
    const response = fetch("OrderManagement/AddOrder", my - form){
      method: 'POST',
      body: JSON.stringify(my - form),
        headers: {
      'Accept': 'application/json',
        'Content-Type': 'application/json'
    }

    alert("Order has been added!");
  });

  }
</script>

<template>
  <form class="my-form">
    <input v-model="customerName" type="text" placeholder="Enter Customer Name" />
    <br />
    <input v-model="productName" type="text" placeholder="Enter Product Name" />
    <br />
    <p>Enter quanity number</p><br />
    <input v-model="quantity" type="number" /><br />
    <div>
      <button @click="addOrder">Add Order</button>
    </div>
  </form>
  <br />
  <br />
  <div style="display:block">
    Name: {{ customerName }}<br />
    Product: {{ productName }}<br />
    Quantity: {{ quantity }}<br />
  </div>

</template>
