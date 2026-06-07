function formatDate(value) {
  if (!value) return '-';
  return new Date(value).toLocaleString('pt-BR');
}

async function request(url, options = {}) {
  const response = await fetch(url, {
    headers: { 'Content-Type': 'application/json', ...(options.headers || {}) },
    ...options,
  });
  const text = await response.text();
  try { return { ok: response.ok, status: response.status, data: text ? JSON.parse(text) : null }; }
  catch { return { ok: response.ok, status: response.status, data: text }; }
}

function renderRows(targetId, items, rowBuilder) {
  const tbody = document.getElementById(targetId);
  tbody.innerHTML = items.length
    ? items.map(rowBuilder).join('')
    : '<tr><td colspan="99" class="text-center text-light-emphasis">Nenhum registro encontrado.</td></tr>';
}
