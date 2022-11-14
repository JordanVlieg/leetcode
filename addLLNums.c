/**
 *  * Definition for singly-linked list.
 *   * struct ListNode {
 *    *     int val;
 *     *     struct ListNode *next;
 *      * };
 *       */
struct ListNode* addTwoNumbers(struct ListNode* l1, struct ListNode* l2) {
    struct ListNode* head = l1;
    int carry = 0;
    for(;l1 != NULL;)
    {
        if(l1->next == NULL && l2->next != NULL){//if L1 is smaller than L2
            l1->next = l2->next;
        }
        int l2V = 0;
        if(l2 != NULL){
            l2V = l2->val;
            l2 = l2->next;
        }
        int tmp = (l1->val + l2V + carry) % 10;
        carry = (l1->val + l2V) / 10;
        l1->val = tmp;
        if(l1->next == NULL && carry == 1){
            struct ListNode* newNode = malloc(sizeof(struct ListNode));
            newNode->val = 1;
            newNode->next = NULL;
            l1->next = newNode;
        }
        else{
            l1 = l1->next;
        }
    }
    return head;
}
