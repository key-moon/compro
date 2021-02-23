// detail: https://atcoder.jp/contests/abc066/submissions/20445853
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

int main() {
  int n;
  cin >> n;
  deque<int> q{};
  for (int i = 0; i < n; i++) {
    int a;
    cin >> a;
    if ((i ^ n) & 1) q.push_front (a);
    else q.push_back(a);
  }
  for (int i = 0; i < n; i++) {
    if (i != 0) cout << " ";
    cout << q[i];
  }
  cout << endl;
}
