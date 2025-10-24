function formatBGN(x) {
  return Number(x.toFixed(2)).toString().replace('.', ',') + ' лв';
}

document.getElementById('pizza-form').addEventListener('submit', function (e) {
  e.preventDefault();

  const name = document.getElementById('name').value.trim();
  const email = document.getElementById('email').value.trim();
  const qty = parseInt(document.getElementById('qty').value, 10);

  const pizzaRadio = document.querySelector('input[name="pizza"]:checked');
  const resultEl = document.getElementById('result');

  const pizzaName = pizzaRadio.value;
  const basePrice = parseFloat(pizzaRadio.dataset.price); 

  const sizeSel = document.getElementById('size');
  const sizeName = sizeSel.value;
  const sizeExtra = parseFloat(sizeSel.selectedOptions[0].dataset.extra); 

  const unitPrice = basePrice + sizeExtra;
  const total = unitPrice * qty;

  resultEl.textContent =
    `Здравей, ${name}! Поръчката: ${pizzaName} (${formatBGN(basePrice)}), ` +
    `${sizeName} (+${formatBGN(sizeExtra)}) × ${qty} = ${formatBGN(total)}.`;
});