// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/1179/judge/4896345/C++14
#include <bits/stdc++.h>

#define var auto
#define ll long long

using namespace std;

int main() {
	int n;
	cin >> n;
	vector<vector<int>> query(n, vector<int>(3));
	for (size_t i = 0; i < n; i++)
	{
		cin >> query[i][0] >> query[i][1] >> query[i][2];
	}
	vector<int> res(n);
	
	int time = 0;
	for (size_t i = 1; i < 1000; i++)
	{
		for (size_t j = 1; j <= 10; j++)
		{
			var limit = i % 3 == 0 ? 20 : 19 + (j & 1);
			for (size_t k = 1; k <= limit; k++)
			{
				for (size_t l = 0; l < n; l++)
				{
					if (query[l][0] == i && query[l][1] == j && query[l][2] == k) {
						res[l] = time;
						break;
					}
				}
				time++;
			}
		}
	}
	for (size_t i = 0; i < n; i++)
	{
		cout << time - res[i] << endl;
	}
}


