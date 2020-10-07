// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/2883/judge/4895979/C++14
#include <bits/stdc++.h>
using namespace std;

int calc(string& s, vector<int>& p, int& i) {
    assert(i < s.size());
    int val;
    if (s[i] == '[') {
        i++; //開きカッコの読み飛ばし

        char op = s[i]; i++; //オペレータの読み込み

        int a = calc(s, p, i); //第1変数の読み込み
        int b = calc(s, p, i); //第2変数の読み込み

        assert(s[i] == ']'); i++; //閉じカッコの読み飛ばし

        switch (op) {
        case '+':
            val = a | b;
            break;
        case '*':
            val = a & b;
            break;
        case '^':
            val = a ^ b;
            break;
        }
    }
    //整数分
    else {
        assert('a' <= s[i] && s[i] <= 'd');
        val = p[s[i] - 'a']; i++; //変数の読み込み
    }

    return val;
}

signed main() {
    while (1) {
        string s, p;
        cin >> s;
        if (s == ".") break;
        cin >> p;

        vector<int> v{ p[0] - '0', p[1] - '0', p[2] - '0', p[3] - '0' };

        int ind = 0;
        int hash = calc(s, v, ind);

        int res = 0;
        for (int i = 0; i < 10; i++) {
            for (int j = 0; j < 10; j++) {
                for (int k = 0; k < 10; k++) {
                    for (int l = 0; l < 10; l++) {
                        vector<int> v{ i, j, k, l };
                        int ind = 0;
                        if (hash == calc(s, v, ind)) res++;
                    }
                }
            }
        }
        cout << hash << " " << res << endl;
    }
}

