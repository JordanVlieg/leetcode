/**
 * Definition for singly-linked list.
 * struct ListNode {
 *     int val;
 *     struct ListNode *next;
 * };
 */
struct ListNode* addTwoNumbers(struct ListNode* l1, struct ListNode* l2) {
    struct ListNode* head = l1;
    int carry = 0;
    int sum = 0;
    while(l1 != NULL)
    {
        if(l1->next == NULL && l2 != NULL) // L2 is longer
        {
            l1->next = l2->next;
            l2->next = NULL;
        }
        int l2Val = 0;
        if(l2 != NULL)
        {
            l2Val = l2->val;
            l2 = l2->next;
        }
        sum = (l1->val + l2Val + carry) % 10;
        carry = (l1->val + l2Val + carry) / 10;
        l1->val = sum;
        if(carry == 1 && l1->next == NULL)
        {
            struct ListNode* newNode = malloc(sizeof(struct ListNode));
            newNode->val = 1;
            newNode->next = NULL;
            l1->next = newNode;
            break;
        }
        l1 = l1->next;
    }
    return head;
}