// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/0337/judge/3863072/C++14
#include <bits/stdc++.h>
using namespace std;

int main() {
    int e, y;
    cin >> e >> y;
    if (e == 0)
    {
        if (y <= 1911) cout << "M" << y - 1867;
        else if (y <= 1925) cout << "T" << y - 1911;
        else if (y <= 1988) cout << "S" << y - 1925;
        else cout << "H" << y - 1988;
    }
    else
    {
        int offset[] = { 1867, 1911, 1925, 1988 };
        cout << offset[e - 1] + y;
    }
    cout << endl;
}

