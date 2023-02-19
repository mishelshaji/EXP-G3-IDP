declare interface ActionCreateDto {
    name: string;

    endDate: Date

    objective: number

    userId: number
    /**
     * The description of the action. It should be a short description of the
     * action and should not exceed 250 characters.
     */
    description: string;
}
