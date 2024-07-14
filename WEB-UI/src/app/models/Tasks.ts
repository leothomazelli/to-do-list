import { StatusEnum } from '../enum/StatusEnum';
import { User } from './User';

export interface Tasks {
  id: number;
  title: string;
  summary: string;
  status: StatusEnum;
  createdAt: Date;
  dueDate: Date;
  userId: number;
  user: User;
}
