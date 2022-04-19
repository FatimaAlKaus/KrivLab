import { Status } from "../models/status";

const REQUEST_URL = "https://localhost:44390/api/statuses/";

export const getAllStatuses = async () => {
  const response = await fetch(REQUEST_URL);
  return await response.json();
};
export const deleteStatusById = async (id: number) => {
  await fetch(REQUEST_URL + "?id=" + id, {
    method: "DELETE",
  });
};

export const updateStatus = async (status: Status) => {
  await fetch(REQUEST_URL, {
    method: "PUT",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify({ id: status.id, newName: status.name }),
  });
};
export const createStatus = async (name: string) => {
  await fetch(REQUEST_URL, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify({ name: name }),
  });
};
