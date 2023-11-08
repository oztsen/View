// view.model.ts
export interface View {
  id: string;
  viewName: string;
  databaseName: string | null;
  userName: string | null;
  password: string | null;
  customerKey: string | null;
  orderId: number | null;
  reportName: string | null;
  viewType: string | null;
  parameters: string | null;
  sampleCall: string | null;
}
