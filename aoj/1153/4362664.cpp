// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/1153/judge/4362664/C++14
#include <bits/stdc++.h>

#define var auto
#define long long long
using namespace std;

int main() {
    while(true){
        int n, m;
        cin >> n >> m;
        if (n == 0) break;
        vector<int> a(n), b(m);
        for (int i = 0; i < n; ++i) cin >> a[i];
        for (int i = 0; i < m; ++i) cin >> b[i];
        var aSum = accumulate(a.begin(), a.end(), 0);
        var bSum = accumulate(b.begin(), b.end(), 0);
        var diff = aSum - bSum;
        int resA = INT32_MAX;
        int resB = INT32_MAX;
        for (int i = 0; i < n; ++i) {
            for (int j = 0; j < m; ++j) {
                if ((a[i] - b[j]) * 2 == diff && a[i] < resA){
                    resA = a[i];
                    resB = b[j];
                }
            }
        }
        if (resA == INT32_MAX){
            cout << -1 << endl;
            continue;
        }
        cout << resA << " " << resB << endl;
    }
}

