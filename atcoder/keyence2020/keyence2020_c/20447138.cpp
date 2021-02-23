// detail: https://atcoder.jp/contests/keyence2020/submissions/20447138
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

int main() {
  int n, k, s;
  cin >> n >> k >> s;
  for (int i = 0; i < k; i++) {
    cout << s << " ";
  }
  int special = s == (int)1e9 ? 1 : (int)1e9;
  for (int i = k; i < n; i++) {
    cout << special << " ";
  }
  cout << endl;
}
